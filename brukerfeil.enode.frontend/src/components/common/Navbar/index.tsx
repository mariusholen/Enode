import React from 'react'
import { NavLink } from 'react-router-dom'
import styles from './styles.module.css'

const Navbar: React.FC = () => {
    return (
        <div className={styles.container}>
            <h1 className={styles.brand}>Enode</h1>

            <div className={styles.logOut}>
                <NavLink to="/">Logg ut</NavLink>
            </div>
        </div>
    )
}

export default Navbar
