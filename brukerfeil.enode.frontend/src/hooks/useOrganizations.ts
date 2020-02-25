import { useState } from 'react'
import Organization from '../types/Organization'

export default () => {
    const [Organization /*setOrganizations*/] = useState<Organization[]>(
        organizationArray
    )
    return Organization
}

const organizationArray: Organization[] = [
    {
        organizationName: 'Stavanger kommune',
        organizationID: 989778471,
    },

    {
        organizationName: 'Kristiansand kommune',
        organizationID: 991825827,
    },

    {
        organizationName: 'Sandnes kommune',
        organizationID: 987464291,
    },

    {
        organizationName: 'Atea',
        organizationID: 989778471,
    },

    {
        organizationName: 'Skatteetaten',
        organizationID: 991825827,
    },

    {
        organizationName: 'Laanekassen',
        organizationID: 987464291,
    },
]
