<?php
/**
 *  pmapisubscriber.class.inc:
 * 
 *  Please note: This class is intended for light use only and will be inefficient if used to
 *  bulk update/create subscribers.
 *
 *    Part of the Sign-Up.to Permission Marketing API v0.1 Redistributable
 *
 *
 *  Copyright (c) 2013 Sign-Up Technologies Ltd.
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions are met:
 *
 *  1. Redistributions of source code must retain the above copyright notice, this
 *     list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright notice,
 *     this list of conditions and the following disclaimer in the documentation
 *     and/or other materials provided with the distribution.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 *  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 *  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 *  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 *  ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 *  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 *  LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 *  ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 *  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 */


class PMAPISubscriber
{
    public $id;

    private $request;
    private $data = array(
        'companyname' => null,
        'confirmed'   => null,
        'country'     => null,
        'county'      => null,
        'daybirth'    => null,
        'email'       => null,
        'firstname'   => null,
        'housenumber' => null,
        'lastname'    => null,
        'list_id'     => null,
        'monthbirth'  => null,
        'msisdn'      => null,
        'postcode'    => null,
        'streetname'  => null,
        'title'       => null,
        'town'        => null,
        'yearbirth'   => null,
    );
    private $subscriberProfileData = array();
    private $subscriberProfileFields = array();
    private $modifiedFields = array();


    public function __construct(PMAPIRequest $request, $id = null, $email = null, $msisdn = null)
    {
        $this->request = $request;

        if (is_null($id) && !is_null($email))
        {
            $id = $this->getSubscriberIdFromEmail($email);
        }
        else if (is_null($id) && !is_null($msisdn))
        {
            $id = $this->getSubscriberIdFromMSISDN($msisdn);
        }

        if ($id)
        {
            $this->id = (int) $id;
            $this->loadSubscriber();
            $this->loadSubscriberProfileFields();
            $this->loadSubscriberProfileData();
        }
        else
        {
            $this->loadSubscriberProfileFields();
        }
    }


    /*
     * addToList
     *
     * Add a subscriber to a list
     *
     * @return (boolean) success
     */
    public function addToList($listId)
    {
		if (!$this->id)
		{
			throw new PMAPISubscriberNotSavedException();
		}

        $response = $this->request->subscription->post(array(
            'subscriber_id' => $this->id,
            'list_id'       => $listId
        ));

        if ($response->isError && $response->response['response']['resource_id'])
        {
            // The subscription already exists, return true
            return true;
        }
        else if ($response->isError)
        {
            throw new PMAPISubscriberSubscriptionException($response->error);
        }

        return true;
    }


    /*
     * deleteFromList
     *
     * Delete a subscriber's subscription to a list
     *
     * @return (boolean) success
     */
    public function deleteFromList($listId)
    {
		if (!$this->id)
		{
			throw new PMAPISubscriberNotSavedException();
		}

        // Get the subscription id
        $response = $this->makeGetRequest('subscription', array(
            'subscriber_id' => $this->id,
            'list_id'       => $listId
        ));

        $subscriptionId = $response->data[0]['id'];

        $response = $this->request->subscription->delete(array(
            'id' => $subscriptionId
        ));

        if ($response->isError)
        {
            throw new PMAPISubscriberUnableToDeleteListException($response->error);
        }

        return true;
    }


    /*
     * getSubscriberIdFromEmail
     *
     * Retrieve the subscriber's id for a given email address
     *
     * @return (int) subscriber id
     */
    private function getSubscriberIdFromEmail($email)
    {
        $response = $this->makeGetRequest('subscriber', array('email' => $email));
        return (int) $response->data[0]['id'];
    }


    /*
     * getSubscriberIdFromMSISDN
     *
     * Retrieve the subscriber's id for a given msisdn
     *
     * @return (int) subscriber id
     */
    private function getSubscriberIdFromMSISDN($msisdn)
    {
        $response = $this->makeGetRequest('subscriber', array('msisdn' => $msisdn));
        return (int) $response->data[0]['id'];
    }


    /*
     * loadSubscriber
     *
     * Retrieve the subscriber's data from PMAPI
     */
    private function loadSubscriber()
    {
        $response = $this->makeGetRequest('subscriber', array('id' => $this->id));

        $this->data = $response->data;
    }


    /*
     * loadSubscriberProfileFields
     *
     * Retrieve the list of possible subscriber profile fields from PMAPI
     */
    private function loadSubscriberProfileFields()
    {
        // Get all the subscriber profile fields
        $data = array('count' => 100);

        // Iterate through the all subscriber profile records, this may require more than 1 request
        // depending on how many subscriber profile fields exist.
        while ($data)
        {
            if ($response = $this->request->subscriberProfileField->get($data))
            {
                foreach ($response->data as $item)
                {
                    $this->subscriberProfileFields[$item['columnheader']] = $item['id'];
                    $this->subscriberProfileData[$item['columnheader']]   = null;
                }

                if ($response->next)
                {
                    $data['start'] = $response->next;
                }
                else
                {
                    $data = false;
                }
            }
            else
            {
                $data = false;
            }
        }
    }


    /*
     * loadSubscriberProfileData
     *
     * Retrieve the subscriber's profile data from PMAPI
     */
    private function loadSubscriberProfileData()
    {
        foreach ($this->subscriberProfileFields as $columnHeader => $id)
        {
            try
            {
                $response = $this->makeGetRequest('subscriberProfileData', array(
                    'subscriberprofilefield_id' => $id,
                    'subscriber_id'             => $this->id
                ));

                $this->subscriberProfileData[$columnHeader] = $response->data[0]['value'];
            }
            catch(PMAPISubscriberRecordDoesNotExist $e)
            {
				// Records will not exist unless they have been set. 
            }
        }
    }


    /*
     * makeGetRequest
     *
     * A wrapper for making GET requests.
     *
     * @return PMAPIResponse $response
     */
    private function makeGetRequest($endpoint, $data = array())
    {
        $response = $this->request->$endpoint->get($data);

        if ($response->isError)
        {
            throw new PMAPISubscriberRecordDoesNotExistException($response->error);
        }

        return $response;
    }


    /*
     * save
     *
     * Save/Update the subscriber's data and associated profile fields
     *
     * @return boolean $success
     */
    public function save()
    {
        if (!$this->modifiedFields)
        {
            return true;
        }

        //
        $subscriberData        = array();
        $subscriberProfileData = array();

        foreach ($this->modifiedFields as $field => $oldvalue)
        {
            if (isset($this->data[$field]))
            {
                $subscriberData[$field] = $this->$field;
            }

            if (isset($this->subscriberProfileData[$field]))
            {
                $subscriberProfileData[$field] = $this->$field;
            }
        }

        // Update the subscriber record
        if ($subscriberData)
        {
            if ($this->id)
            {
                $subscriberData['id'] = $this->id;
                $method               = 'put';
            }
            else
            {
                $method = 'post';
            }

            $response = $this->request->subscriber->$method($subscriberData);

            if ($response->isError)
            {
                throw new PMAPISubscriberUnableToSaveSubscriberException($response->error);
            }

            if (!$this->id)
            {
                $this->id = $response->data['id'];
            }
        }

        // Update the subscriber profile fields
        if ($subscriberProfileData)
        {
            foreach ($subscriberProfileData as $key => $value)
            {
                $response = $this->request->subscriberProfileData->put(array(
                    'subscriber_id'             => $this->id,
                    'subscriberprofilefield_id' => $this->subscriberProfileFields[$key],
                    'value'                     => $value
                ));

                if ($response->isError)
                {
                    throw new PMAPISubscriberUnableToSaveSubscriberProfileDataException($response->error);
                }
            }
        }

        return true;
    }


    public function __get($what)
    {
        if (array_key_exists($what, $this->data))
        {
            return $this->data[$what];
        }
        else if (array_key_exists($what, $this->subscriberProfileData))
        {
            return $this->subscriberProfileData[$what];
        }
        else
        {
            throw new PMAPISubscriberUnsupportedFieldException($what);
        }
    }


    public function __isset($what)
    {
        return (array_key_exists($what, $this->data) || array_key_exists($what, $this->subscriberProfileFields));
    }


    public function __set($key, $value)
    {
        if (!isset($this->$key))
        {
            throw new PMAPISubscriberUnsupportedFieldException($key);
        }

        if (array_key_exists($key, $this->data))
        {
            if ($this->data[$key] != $value)
            {
                $this->modifiedFields[$key] = $this->data[$key];
                $this->data[$key]           = $value;
            }
        }
        else if (array_key_exists($key, $this->subscriberProfileFields))
        {
            if ($this->subscriberProfileData[$key] != $value)
            {
                $this->modifiedFields[$key]        = $this->subscriberProfileData[$key];
                $this->subscriberProfileData[$key] = $value;
            }
        }
    }
}

class PMAPISubscriberException extends Exception
{
}

class PMAPISubscriberUnableToSaveSubscriberException extends PMAPISubscriberException
{
}

class PMAPISubscriberUnableToSaveSubscriberProfileDataException extends PMAPISubscriberException
{
}

class PMAPISubscriberUnsupportedFieldException extends PMAPISubscriberException
{
}

class PMAPISubscriberRecordDoesNotExistException extends PMAPISubscriberException
{
}

class PMAPISubscriberSubscriptionException extends PMAPISubscriberException
{
}

class PMAPISubscriberUnableToDeleteListException extends PMAPISubscriberException
{
}

class PMAPISubscriberNotSavedException extends PMAPISubscriberException
{
}
