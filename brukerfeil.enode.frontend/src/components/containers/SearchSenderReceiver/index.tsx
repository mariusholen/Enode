import React from 'react'
import { useState } from 'react'
import styles from './styles.module.css'

type SearchSenderReceiver = {
    placeholder: string
    onSearch: (id: string) => void
    onClear: () => void
}

const SearchSenderReceiver: React.FC<SearchSenderReceiver> = props => {
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
        <div className={styles.container}>
            <form onSubmit={handleSubmit}>
                <input
                    className={styles.search}
                    type="text"
                    maxLength={9}
                    value={id}
                    onChange={e => setId(e.target.value)}
                    placeholder={props.placeholder}
                />
                <button className={styles.confirmButton}>Bekreft</button>
                <button className={styles.clearButton} onClick={handleClear}>
                    Klarer søk
                </button>
            </form>
        </div>
    )
}

export default SearchSenderReceiver
