import React from 'react'
import { useState } from 'react'
import styles from './styles.module.css'

type SearchSenderReceiver = {
    placeholder: string
    onSearch: (id: string) => void
    onClear: () => void
    styling?: StylesType
}

type StylesType = {
    readonly [key: string]: string
}

const SearchSenderReceiver: React.FC<SearchSenderReceiver> = ({
    styling = styles,
    ...props
}) => {
    const [id, setId] = useState('')

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        if (id) {
            e.preventDefault()
            props.onSearch(id)
        } else {
            e.preventDefault()
        }
    }

    const handleClear = (
        e: React.MouseEvent<HTMLButtonElement, MouseEvent>
    ) => {
        e.preventDefault()
        if (id) {
            props.onClear()
            setId('')
        }
    }

    return (
        <div className={styles.searchContainer}>
            <form onSubmit={handleSubmit}>
                <fieldset className={styling.fieldset}>
                    <input
                        className={styling.search}
                        type="number"
                        maxLength={9}
                        value={id}
                        onChange={e => setId(e.target.value)}
                        placeholder={props.placeholder}
                    />
                    <button className={styling.confirmButton}>Bekreft</button>
                    <button
                        className={styling.clearButton}
                        onClick={handleClear}
                    >
                        Klarer søk
                    </button>
                </fieldset>
            </form>
        </div>
    )
}

export default SearchSenderReceiver
