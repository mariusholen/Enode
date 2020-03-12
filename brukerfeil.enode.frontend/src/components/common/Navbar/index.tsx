import React from 'react'
import styles from './styles.module.css'
import SearchSenderReceiver from '../../containers/SearchSenderReceiver'
import { FaFilter } from 'react-icons/fa/'
import { TiThMenu } from 'react-icons/ti'
import useOneOrganization from '../../../hooks/useOneOrganization'
import Organization from '../../../types/Organization'

type Message = {
    searchHandlerReceiver: (id: string) => void
    clearReceiver: () => void
}

const Navbar: React.FC = () => {
    const { organization } = useOneOrganization()
    const renderOrganization = (o: Organization) => {
        return <div>{o.organizationName}</div>
    }

    var id: '12345' //messageId-search placeholder
    return (
        <div className={styles.container}>
            <TiThMenu className={styles.hamburger} />
            <h1 className={styles.brand}>Enode</h1>
            <h2 className={styles.organization}>
                {organization.map(renderOrganization)}
            </h2>
            <div className={styles.searchContent}>
                <SearchSenderReceiver
                    placeholder={'Søk på messageId...'}
                    onSearch={id => id}
                    onClear={() => id}
                    styling={styles}
                />
            </div>
            <FaFilter className={styles.filter} />
        </div>
    )
}

export default Navbar
