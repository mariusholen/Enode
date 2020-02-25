import { useState, useEffect } from 'react'
import Message from '../types/Message'
import {
    BACKEND_BASEURL,
    MESSAGES_IN_ENDPOINT,
    MESSAGES_OUT_ENDPOINT,
} from '../constants'

const options = {
    headers: { 'Content-type': 'application/json' },
    method: 'GET',
}

export default (orgId: string) => {
    const [tempInMessages, setTempInMessages] = useState<Message[]>([])
    const [tempOutMessages, setTempOutMessages] = useState<Message[]>([])
    const [isFetching, setIsFetching] = useState<boolean>(true)
    const [error, setError] = useState<string>('')

    const fetchBySenderID = async (id: string): Promise<Message[]> => {
        const endpoint =
            orgId !== '1'
                ? `${BACKEND_BASEURL}/message/${orgId}/sender/${id}`
                : `${BACKEND_BASEURL}/message/sender/${id}`

        const response = await fetch(endpoint, options)
        const result = (await response.json()) as Message[]
        return result
    }

    const fetchByReceiverID = async (id: string): Promise<Message[]> => {
        const endpoint =
            orgId !== '1'
                ? `${BACKEND_BASEURL}/message/${orgId}/receiver/${id}`
                : `${BACKEND_BASEURL}/message/receiver/${id}`

        const response = await fetch(endpoint, options)
        const result = (await response.json()) as Message[]
        return result
    }

    const fetchMessages = async (endpoint: string) => {
        setIsFetching(true)

        const tempUrl =
            endpoint === MESSAGES_IN_ENDPOINT
                ? `${BACKEND_BASEURL}${MESSAGES_IN_ENDPOINT}`
                : `${BACKEND_BASEURL}${MESSAGES_OUT_ENDPOINT}`
        const url = orgId !== '1' ? `${tempUrl}/${orgId}` : tempUrl
        try {
            const response = await fetch(url, options)
            const result = (await response.json()) as Message[]

            endpoint === MESSAGES_IN_ENDPOINT
                ? setTempInMessages(result)
                : setTempOutMessages(result)
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
        fetchBySenderID,
        fetchByReceiverID,
    }
}
