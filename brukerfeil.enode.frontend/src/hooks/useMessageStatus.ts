import { useState, useEffect } from 'react'
import MessageStatus from '../types/MessageStatus'
import { BACKEND_BASEURL, MESSAGE_STATUS_ENDPOINT } from '../constants'

export default (messageId: string) => {
    const [statuses, setStatuses] = useState<MessageStatus[]>([])
    const [isFetching, setIsFetching] = useState<boolean>(false)
    const [error, setError] = useState<string>('')

    const fetchMessageStatus = async () => {
        setIsFetching(true)

        try {
            const response = await fetch(
                `${BACKEND_BASEURL}${MESSAGE_STATUS_ENDPOINT}/${messageId}`,
                {
                    method: 'GET',
                }
            )
            const result = (await response.json()) as MessageStatus[]
            console.log(result)
            setStatuses(result)
        } catch (exception) {
            console.log(`Error when fetching Message Status: ${exception}`)
            setError(`Error when fetching Message Status: ${exception}`)
        }
        setIsFetching(false)
    }

    useEffect(() => {
        if (messageId) {
            fetchMessageStatus()
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [messageId])

    return { statuses, error, isFetching }
}
