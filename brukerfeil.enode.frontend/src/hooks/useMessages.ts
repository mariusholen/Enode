import { useState, useEffect } from 'react'
import axios from 'axios'
import { httpResponseHandler } from '../utils/utils'
import Message from '../types/Message'
import {
    BACKEND_BASEURL,
    MESSAGES_IN_ENDPOINT,
    MESSAGES_OUT_ENDPOINT,
} from '../constants'

const headers = {
    headers: { 'Content-type': 'application/json' },
}

/**
 * Fetching related functions for messages for an organization.
 * @param {string} orgId
 *  The logged in user's organization id
 * @returns in- and outgoing messages, loading indicator, functions to search for filtered messages and an error object.
 */
export default (orgId: string) => {
    const [tempInMessages, setTempInMessages] = useState<Message[]>([])
    const [tempOutMessages, setTempOutMessages] = useState<Message[]>([])
    const [isFetching, setIsFetching] = useState<boolean>(true)
    const [error, setError] = useState<string>('')

    /**
     * Fetches ingoing messages for the selected organization based on a specified sender, and updates the 'tempInMessages' state.
     * @param {string} id
     *  The sender's organization id.
     */
    const fetchBySenderId = async (id: string): Promise<void> => {
        setIsFetching(true)
        try {
            const endpoint =
                orgId !== '1'
                    ? `${BACKEND_BASEURL}/message/${orgId}/sender/${id}`
                    : `${BACKEND_BASEURL}/message/sender/${id}`

            const response = await axios.get<Message[]>(endpoint, headers)
            httpResponseHandler(response, setTempInMessages, setError)
        } catch (exception) {
            console.log(`Error when fetching messages: ${exception}`)
            setError(`Error when fetching messages: ${exception}`)
        }
        setIsFetching(false)
    }

    /**
     * Fetches outgoing messages for the selected organization based on a specified recipient.
     * @param {string} id
     *  The recipient's organization id.
     */
    const fetchByReceiverId = async (id: string): Promise<void> => {
        setIsFetching(true)
        try {
            const endpoint =
                orgId !== '1'
                    ? `${BACKEND_BASEURL}/message/${orgId}/receiver/${id}`
                    : `${BACKEND_BASEURL}/message/receiver/${id}`

            const response = await axios.get<Message[]>(endpoint, headers)
            httpResponseHandler(response, setTempOutMessages, setError)
        } catch (exception) {
            console.log(`Error when fetching messages: ${exception}`)
            setError(`Error when fetching messages: ${exception}`)
        }
        setIsFetching(false)
    }

    /**
     * Fetches either incoming or outgoing messages for an organization, and sets the state with the messages.
     *
     * @param {string } endpoint
     *  The endpoint messages will be fetched from.
     */
    const fetchMessages = async (endpoint: string): Promise<void> => {
        const tempUrl =
            endpoint === MESSAGES_IN_ENDPOINT
                ? `${BACKEND_BASEURL}${MESSAGES_IN_ENDPOINT}`
                : `${BACKEND_BASEURL}${MESSAGES_OUT_ENDPOINT}`

        //Check if 'alle organisasjoner' is selected
        const url = orgId !== '1' ? `${tempUrl}/${orgId}` : tempUrl
        try {
            const response = await axios.get<Message[]>(url, headers)

            httpResponseHandler(
                response,
                endpoint === MESSAGES_IN_ENDPOINT
                    ? setTempInMessages
                    : setTempOutMessages,
                setError
            )
        } catch (exception) {
            console.log(`Error when fetching messages: ${exception}`)
            setError(`Error when fetching messages: ${exception}`)
        }
        setIsFetching(false)
    }

    useEffect(() => {
        fetchMessages(MESSAGES_IN_ENDPOINT)
        fetchMessages(MESSAGES_OUT_ENDPOINT)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return {
        tempInMessages,
        tempOutMessages,
        isFetching,
        error,
        fetchBySenderId,
        fetchByReceiverId,
    }
}
