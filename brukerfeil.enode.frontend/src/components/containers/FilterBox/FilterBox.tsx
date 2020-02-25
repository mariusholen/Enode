import React, { useState } from 'react'
import styles from './styles.module.css'
import SearchSenderReceiver from '../SearchSenderReceiver'
import { FaChevronDown } from 'react-icons/fa'

type FilterBox = {
    searchHandlerSender: (id: string) => void
    searchHandlerReceiver: (id: string) => void
    clearSender: () => void
    clearReceiver: () => void
}

export const FilterBox: React.FC<FilterBox> = props => {
    const [expanded, setExpanded] = useState(false)

    const handleExpandContainer = (
        e: React.MouseEvent<HTMLDivElement, MouseEvent>
    ) => {
        e.preventDefault()
        setExpanded(!expanded)
    }
    return (
        <>
            <div className={styles.container} onClick={handleExpandContainer}>
                <FaChevronDown className={styles.icon} />
            </div>
            <div
                className={
                    !expanded
                        ? styles.compressedContainer
                        : styles.expandedContainer
                }
            >
                <div className={styles.content}>
                    <div className={styles.searchContent}>
                        <SearchSenderReceiver
                            placeholder={'Søk på SenderID'}
                            onSearch={id => props.searchHandlerSender(id)}
                            onClear={props.clearSender}
                        />
                        <SearchSenderReceiver
                            placeholder={'Søk på ReceiverID'}
                            onSearch={id => props.searchHandlerReceiver(id)}
                            onClear={props.clearReceiver}
                        />
                    </div>
                </div>
            </div>
        </>
    )
}
