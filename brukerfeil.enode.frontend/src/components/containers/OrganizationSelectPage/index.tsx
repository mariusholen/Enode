import React from 'react'
import OrganizationList from '../../containers/OrganizationList'
import styles from './styles.module.css'

const Frontpage: React.FC = () => {
    return (
        <div className={styles.frontPage}>
            <div className={styles.container}>
                <h1 className={styles.title}>Enode</h1>
                <OrganizationList />
            </div>
        </div>
    )
}

export default Frontpage
