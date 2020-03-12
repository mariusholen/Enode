import { statusChecker } from './utils'
import { MdError } from 'react-icons/md'
import { FaEnvelopeOpenText } from 'react-icons/fa'
import { MdSend } from 'react-icons/md'
import { MdMarkunreadMailbox } from 'react-icons/md'
import { IoIosTime } from 'react-icons/io'
import { FaEnvelope } from 'react-icons/fa'
import { FaQuestionCircle } from 'react-icons/fa'

const feilRedExpect = {
    style: 'redStatus',
    Icon: MdError,
    color: 'white',
}
const leveTidRedExpect = {
    style: 'redStatus',
    Icon: IoIosTime,
    color: 'white',
}
const levertGreenExpect = {
    style: 'greenStatus',
    Icon: FaEnvelope,
    color: 'white',
}
const lestGreenExpect = {
    style: 'greenStatus',
    Icon: FaEnvelopeOpenText,
    color: 'white',
}
const blueExpect = {
    style: 'blueStatus',
    Icon: MdSend,
    color: '#BEF45A',
}
const purpleExpect = {
    style: 'purpleStatus',
    Icon: MdMarkunreadMailbox,
    color: '#FFCCFF',
}
const annetExpect = {
    style: 'greyStatus',
    Icon: FaQuestionCircle,
    color: 'black',
}

describe('statusChecker', () => {
    it('should return redStatus style', () => {
        const result = statusChecker('FEIL')
        expect(result).toEqual(feilRedExpect)
    })
    it('should return redStatus style', () => {
        const result = statusChecker('LEVETID_UTLOPT')
        expect(result).toEqual(leveTidRedExpect)
    })
    it('should return greenStatus style', () => {
        const result = statusChecker('LEVERT')
        expect(result).toEqual(levertGreenExpect)
    })
    it('should return greenStatus style', () => {
        const result = statusChecker('LEST')
        expect(result).toEqual(lestGreenExpect)
    })
    it('should return blueStatus style', () => {
        const result = statusChecker('SENDT')
        expect(result).toEqual(blueExpect)
    })
    it('should return purpleStatus style', () => {
        const result = statusChecker('MOTTATT')
        expect(result).toEqual(purpleExpect)
    })
    it('should return purpleStatus style', () => {
        const result = statusChecker('INNKOMMENDE_MOTTATT')
        expect(result).toEqual(purpleExpect)
    })
    it('should return purpleStatus style', () => {
        const result = statusChecker('ANNET')
        expect(result).toEqual(annetExpect)
    })
})

describe('statusCheckerNotNull', () => {
    it('should return redStatus style', () => {
        const result = statusChecker('FEIL')
        expect(result).not.toBeNull()
    })
    it('should return redStatus style', () => {
        const result = statusChecker('LEVETID_UTLOPT')
        expect(result).not.toBeNull()
    })
    it('should return greenStatus style', () => {
        const result = statusChecker('LEVERT')
        expect(result).not.toBeNull()
    })
    it('should return greenStatus style', () => {
        const result = statusChecker('LEST')
        expect(result).not.toBeNull()
    })
    it('should return blueStatus style', () => {
        const result = statusChecker('SENDT')
        expect(result).not.toBeNull()
    })
    it('should return purpleStatus style', () => {
        const result = statusChecker('MOTTATT')
        expect(result).not.toBeNull()
    })
    it('should return purpleStatus style', () => {
        const result = statusChecker('INNKOMMENDE_MOTTATT')
        expect(result).not.toBeNull()
    })
    it('should return purpleStatus style', () => {
        const result = statusChecker('ANNET')
        expect(result).not.toBeNull()
    })
})
