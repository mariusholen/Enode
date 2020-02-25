import React, { useState, useEffect } from 'react'
import usePrevious from '../../../hooks/usePrevious'
import { match } from 'react-router-dom'
import useMessages from '../../../hooks/useMessages'
import styles from './styles.module.css'
import useMessageStatus from '../../../hooks/useMessageStatus'
import InOrOutbox from '../../common/InOrOutbox'
import Message from '../../../types/Message'
import Navbar from '../../common/Navbar'
import { FilterBoxContainer } from '../FilterBox/index'
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

    const [activeId, setActiveId] = useState('')
    const [inMessages, setInMessages] = useState<Message[]>([])
    const [outMessages, setOutMessages] = useState<Message[]>([])

    const { statuses } = useMessageStatus(activeId)

    const {
        tempInMessages,
        tempOutMessages,
        isFetching,
        fetchBySenderID,
        fetchByReceiverID,
    } = useMessages(orgId)

    const previousMessages = usePrevious<InAndOutMessages>({
        inMessages,
        outMessages,
    })

    useEffect(() => {
        setInMessages(tempInMessages)
        setOutMessages(tempOutMessages)
    }, [tempInMessages, tempOutMessages])

    const handleSearchByReceiverId = async (id: string) => {
        setOutMessages(await fetchByReceiverID(id))
    }
    const handleSearchBySenderId = async (id: string) => {
        const result = await fetchBySenderID(id)
        setInMessages(result)
    }
    const handleClearIncomingMessages = async () => {
        if (previousMessages) setInMessages(previousMessages.inMessages)
    }
    const handleClearOutgoingMessages = async () => {
        if (previousMessages) setOutMessages(previousMessages.outMessages)
    }
    return (
        <>
            <Navbar />
            <FilterBoxContainer
                onSearchSenderId={handleSearchBySenderId}
                onSearchReceiverId={handleSearchByReceiverId}
                onClearIncomingMessages={handleClearIncomingMessages}
                onClearOutgoingMessages={handleClearOutgoingMessages}
            />
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
                                    onChangeActive={setActiveId}
                                    selectedStatuses={statuses}
                                />
                                <InOrOutbox
                                    direction="OUT"
                                    messages={outMessages}
                                    onChangeActive={setActiveId}
                                    selectedStatuses={statuses}
                                />
                            </>
                        ) : (
                            <>
                                <InOrOutbox
                                    direction="IN"
                                    messages={[...inMessages, ...outMessages]}
                                    onChangeActive={setActiveId}
                                    selectedStatuses={statuses}
                                />
                            </>
                        )}
                        {statuses.length > 0 && activeId ? (
                            <MessageModal
                                statuses={statuses}
                                onCloseModal={() => setActiveId('')}
                            />
                        ) : null}
                    </>
                )}
            </div>
        </>
    )
}
export default MessagesPage
