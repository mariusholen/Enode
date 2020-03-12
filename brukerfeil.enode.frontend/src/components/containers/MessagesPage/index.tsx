import React, { useState, useEffect } from 'react'
import usePrevious from '../../../hooks/usePrevious'
import { match } from 'react-router-dom'
import useMessages from '../../../hooks/useMessages'
import styles from './styles.module.css'
import useMessageStatus from '../../../hooks/useMessageStatus'
import InOrOutbox from '../../common/InOrOutbox'
import Message from '../../../types/Message'
import Navbar from '../../common/Navbar'
import MessageModal from '../../MessageModal'

type MessagesPageRouteParams = {
    id: string
}

export type MessagesPageProps = {
    match: match<MessagesPageRouteParams>
}

type InAndOutMessages = {
    inMessages: Message[]
    outMessages: Message[]
}

const MessagesPage: React.FC<MessagesPageProps> = props => {
    const orgId = props.match.params.id
    const findMessage = (id: string) => {
        const message = [...inMessages, ...outMessages].find(
            m => m.messageId === id
        )

        if (message) {
            setActiveMessage(message)
        }
    }

    const [activeMessage, setActiveMessage] = useState<Message>()
    const [inMessages, setInMessages] = useState<Message[]>([])
    const [outMessages, setOutMessages] = useState<Message[]>([])

    const { statuses } = useMessageStatus(
        activeMessage ? activeMessage.messageId : ''
    )

    const {
        tempInMessages,
        tempOutMessages,
        isFetching,
        fetchBySenderId,
        fetchByReceiverId,
    } = useMessages(orgId)

    const previousMessages = usePrevious<InAndOutMessages>({
        inMessages,
        outMessages,
    })

    const handleClearIncomingMessages = async () => {
        if (previousMessages) setInMessages(previousMessages.inMessages)
    }
    const handleClearOutgoingMessages = async () => {
        if (previousMessages) setOutMessages(previousMessages.outMessages)
    }

    useEffect(() => {
        setInMessages(tempInMessages)
        setOutMessages(tempOutMessages)
    }, [tempInMessages, tempOutMessages])

    return (
        <>
            <Navbar />
            <div className={styles.container}>
                {isFetching ? (
                    <pre>Loading..</pre>
                ) : (
                    <>
                        {orgId !== '1' ? (
                            <>
                                <InOrOutbox
                                    direction="IN"
                                    messages={inMessages}
                                    onChangeActive={id => findMessage(id)}
                                    onSearchSenderId={fetchBySenderId}
                                    onSearchReceiverId={fetchByReceiverId}
                                    onClearIncomingMessages={
                                        handleClearIncomingMessages
                                    }
                                    onClearOutgoingMessages={
                                        handleClearOutgoingMessages
                                    }
                                />
                                <InOrOutbox
                                    direction="OUT"
                                    messages={outMessages}
                                    onChangeActive={id => findMessage(id)}
                                    onSearchSenderId={fetchBySenderId}
                                    onSearchReceiverId={fetchByReceiverId}
                                    onClearIncomingMessages={
                                        handleClearIncomingMessages
                                    }
                                    onClearOutgoingMessages={
                                        handleClearOutgoingMessages
                                    }
                                />
                            </>
                        ) : (
                            <>
                                <InOrOutbox
                                    direction="IN"
                                    messages={[...inMessages, ...outMessages]}
                                    onChangeActive={id => findMessage(id)}
                                    onSearchSenderId={fetchBySenderId}
                                    onSearchReceiverId={fetchByReceiverId}
                                    onClearIncomingMessages={
                                        handleClearIncomingMessages
                                    }
                                    onClearOutgoingMessages={
                                        handleClearOutgoingMessages
                                    }
                                />
                            </>
                        )}
                        {statuses.length > 0 && activeMessage ? (
                            <MessageModal
                                statuses={statuses}
                                message={activeMessage}
                                onCloseModal={() => setActiveMessage(undefined)}
                            />
                        ) : null}
                    </>
                )}
            </div>
        </>
    )
}
export default MessagesPage
