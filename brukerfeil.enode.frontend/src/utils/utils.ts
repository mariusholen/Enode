import React from 'react'
import { Status } from '../types/Message'
import { FaMinusCircle } from 'react-icons/fa'
import { FaEnvelope } from 'react-icons/fa'
import { MdSend } from 'react-icons/md'
import { MdError } from 'react-icons/md'
import { FaEnvelopeOpenText } from 'react-icons/fa'
import { FaQuestionCircle } from 'react-icons/fa'
import { IoIosTime } from 'react-icons/io'
import { MdMarkunreadMailbox } from 'react-icons/md'
import { AxiosResponse } from 'axios'

//Switch case for determening the STATUS of a message
export const statusChecker = (status: Status) => {
    let Icon: React.FC = FaMinusCircle
    let style = ''
    let color = ''
    switch (status) {
        case null:
            Icon = FaMinusCircle
            style = 'greyStatus'
            color = 'white'
            break
        case 'SENDT':
            Icon = MdSend
            style = 'yellowStatus'
            color = '#BEF45A'
            break
        case 'MOTTATT':
            Icon = MdMarkunreadMailbox
            style = 'yellowStatus'
            color = '#FFCCFF'
            break
        case 'LEVERT':
            Icon = FaEnvelope
            style = 'greenStatus'
            color = 'white'
            break
        case 'LEST':
            Icon = FaEnvelopeOpenText
            style = 'greenStatus'
            color = 'white'
            break
        case 'FEIL':
            Icon = MdError
            style = 'redStatus'
            color = 'white'
            break
        case 'ANNET':
            Icon = FaQuestionCircle
            style = 'greyStatus'
            color = 'black'
            break
        case 'INNKOMMENDE_MOTTATT':
            Icon = MdMarkunreadMailbox
            style = 'yellowStatus'
            color = '#FFCCFF'
            break
        case 'LEVETID_UTLOPT':
            Icon = IoIosTime
            style = 'redStatus'
            color = 'white'
            break
        default:
    }
    return { style, Icon, color }
}

//METHOD FOR SORTING TABLE ROW
// export const sortTing = (messages: Array<Message>) => {
//     return messages.sort((m1, m2) => (m1.lastUpdate > m2.lastUpdate ? 1 : -1))
// }

/**
 * Parses a Date object to a human readable format.
 * @param {Date} dateObject
 *
 */
export const parseDate = (dateObject: Date): string => {
    return new Intl.DateTimeFormat('en-GB', {
        timeZone: 'Europe/Oslo',
        hour12: false,
        formatMatcher: 'best fit',
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
        hour: 'numeric',
        minute: 'numeric',
    }).format(dateObject)
}
//METHOD FOR SORTING TABLE ROW
// export const sortTing = (messages: Array<Message>) => {
//     return messages.sort((m1, m2) => (m1.lastUpdate > m2.lastUpdate ? 1 : -1))
// }

/**
 * Checks HTTP status codes and updates states accordingly
 *
 * @param response
 * An AxiosResponse object
 * @param stateUpdater
 * The setState-function to update the relevant state
 * @param errorUpdater
 * The setState-function to update the error state
 * @throws
 * Exception message includes https status code and text
 */
export const httpResponseHandler = <T>(
    response: AxiosResponse<T[]>,
    stateUpdater: React.Dispatch<React.SetStateAction<T[]>>,
    errorUpdater: React.Dispatch<React.SetStateAction<string>>
) => {
    if (response.status === 200) {
        stateUpdater(response.data)
    } else if (response.status === 204) {
        stateUpdater([])
    } else if (response.status === 400 || 500) {
        errorUpdater(response.data as any)
    } else {
        throw new Error(
            `\nStatus code: ${response.status}. \nStatus text: ${response.statusText}.`
        )
    }
}
