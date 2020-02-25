import React, { useState } from 'react'
import useOrganizations from '../../../hooks/useOrganizations'
import Organization from '../../../types/Organization'
import styles from './styles.module.css'
import { Link } from 'react-router-dom'

const OrganizationList: React.FC = () => {
    const [selectedOrg, setSelectedOrg] = useState<string>('0')
    const organizationList = useOrganizations()
    const handleClick = (
        e: React.MouseEvent<HTMLAnchorElement, MouseEvent>
    ) => {
        if (selectedOrg <= '0') {
            e.preventDefault()
        }
    }
    const renderorganizationList = (o: Organization) => (
        <option
            className={styles.options}
            key={o.organizationName}
            value={o.organizationID}
        >
            {o.organizationName}
        </option>
    )

    return (
        <form className={styles.organizationList}>
            <label className={styles.labeling}>Velg din organisasjon</label>
            <br />
            <select
                className={styles.orgItem}
                value={selectedOrg}
                onChange={e => setSelectedOrg(e.target.value)}
            >
                <option value={0} disabled>
                    Trykk og velg en organisasjon fra listen
                </option>

                {organizationList.map(renderorganizationList)}
                <option value={1}>Alle Organisasjoner</option>
            </select>
            <div>
                <Link to={selectedOrg} onClick={e => handleClick(e)}>
                    <button className={styles.button}>Bekreft</button>
                </Link>
            </div>
        </form>
    )
}

export default OrganizationList
