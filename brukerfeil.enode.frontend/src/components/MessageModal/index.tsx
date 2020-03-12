import React, { useEffect, useCallback, useState } from 'react'
import MessageStatus from '../../types/MessageStatus'
import styles from './styles.module.css'
import Message from '../../types/Message'
import { parseDate } from '../../utils/utils'
// import styles.module.css from '../'

type MessageModalProps = {
    statuses: MessageStatus[]
    message: Message
    onCloseModal: () => void
}

const MessageModal: React.FC<MessageModalProps> = props => {
    const [reverseStatuses, setReverseStatuses] = useState<MessageStatus[]>([])
    const escClick = useCallback(
        (event: KeyboardEvent) => {
            if (event.keyCode === 27) {
                props.onCloseModal()
            }
        },
        [props]
    )

    useEffect(() => {
        document.addEventListener('keydown', escClick, false)

        return () => {
            document.removeEventListener('keydown', escClick)
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    useEffect(() => {
        setReverseStatuses(props.statuses.reverse())
    }, [props.statuses])

    // const { style } = statusChecker(
    //     s.status
    // )
    // const styling = classnames(
    //     styles[style],
    //     styles.bold
    // )

    return (
        <div onClick={() => props.onCloseModal()} className={styles.background}>
            <div
                onClick={event => event.stopPropagation()}
                className={styles.container}
            >
                <button
                    className={styles.exit}
                    onClick={() => props.onCloseModal()}
                >
                    X
                </button>

                <div className={styles.header}>
                    <h1>Melding ID: </h1>
                    <h1 className={styles.messageID}>
                        {props.statuses ? props.statuses[0].messageId : null}{' '}
                    </h1>
                </div>

                <div className={styles.content}>
                    <table className={styles.table}>
                        <caption className={styles.tableHeader}>
                            Meldingsinformasjon
                        </caption>
                        <tbody>
                            <tr>
                                <th>Til</th>
                                <td>{props.message.receiverIdentifier}</td>
                            </tr>
                            <tr>
                                <th>Fra</th>
                                <td>{props.message.senderIdentifier}</td>
                            </tr>
                            <tr>
                                <th>Status</th>
                                <td>{props.message.latestMessageStatus}</td>
                            </tr>
                            <tr>
                                <th>Type</th>
                                <td>{props.message.serviceIdentifier}</td>
                            </tr>
                            <tr>
                                <th>ConvID</th>
                                <td>{props.message.conversationId}</td>
                            </tr>
                            <tr>
                                <th>MsgID</th>
                                <td>{props.message.messageId}</td>
                            </tr>
                        </tbody>
                    </table>

                    <ul className={styles.timeLine}>
                        {reverseStatuses.map((s, i) => {
                            const dateLastUpdate = new Date(s.lastUpdate)
                            return (
                                <React.Fragment key={s.id}>
                                    <li>
                                        <span
                                            className={
                                                i === 0
                                                    ? styles.firstTimeLineItem
                                                    : styles.timeLineItem
                                            }
                                        >
                                            {' '}
                                            {s.status}
                                        </span>
                                        <br />
                                        <div className={styles.lastUpdated}>
                                            {parseDate(dateLastUpdate)}
                                        </div>
                                        <br />
                                    </li>
                                    <div className={styles.ninja}></div>
                                    <span />
                                </React.Fragment>
                            )
                        })}
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default MessageModal
