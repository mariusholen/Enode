import React from 'react'
import { FilterBox } from './FilterBox'

type FilterBoxContainer = {
    onSearchSenderId: (id: string) => void
    onSearchReceiverId: (id: string) => void
    onClearIncomingMessages: () => void
    onClearOutgoingMessages: () => void
}

export const FilterBoxContainer: React.FC<FilterBoxContainer> = props => {
    return (
        <div>
            <FilterBox
                searchHandlerReceiver={props.onSearchReceiverId}
                searchHandlerSender={props.onSearchSenderId}
                clearReceiver={props.onClearOutgoingMessages}
                clearSender={props.onClearIncomingMessages}
            />
        </div>
    )
}
