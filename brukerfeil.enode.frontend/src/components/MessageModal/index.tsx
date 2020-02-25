import React from 'react'
import MessageStatus from '../../types/MessageStatus'
import styles from './styles.module.css'

type MessageModalProps = {
    statuses: MessageStatus[]
    onCloseModal: () => void
}

const MessageModal: React.FC<MessageModalProps> = props => {
    return (
        <div className={styles.background}>
            <div className={styles.container}>
                <button
                    onClick={() => props.onCloseModal()}
                    style={{ color: 'red', fontWeight: 'bolder' }}
                >
                    X
                </button>
                <div className={styles.header}>
                    <h1>Status for melding</h1>
                    {props.statuses ? props.statuses[0].messageId : null}

                    <div className={styles.content}>
                        {props.statuses.map(s => (
                            <p key={s.id}>
                                <br />
                                {s.status}
                                <br />
                                {s.lastUpdate}
                            </p>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default MessageModal
