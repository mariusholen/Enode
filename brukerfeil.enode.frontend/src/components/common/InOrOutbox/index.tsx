import React from 'react'
import Message from '../../../types/Message'
import MessageStatus from '../../../types/MessageStatus'
import { statusChecker } from '../../../utils'
import styles from './styles.module.css'
import { IconContext } from 'react-icons'

type InOrOutboxProps = {
    direction: 'IN' | 'OUT'
    messages: Message[]
    selectedStatuses: MessageStatus[]
    onChangeActive: (messageId: string) => void
    // onDateSort: () => void
    //TODO: Fortesett trykk på header for å sortere ting i listen
}

const InOrOutbox: React.FC<InOrOutboxProps> = ({
    messages,
    direction,
    onChangeActive,
}) => {
    const dirCheck = direction === 'IN'

    return (
        <div>
            <h2>{dirCheck ? 'Innboks' : 'Utboks'}</h2>
            <table className={styles.table}>
                <thead>
                    <tr className={styles.tableHeader}>
                        <th>{dirCheck ? 'Avsender' : 'Mottaker'}</th>
                        <th>Dato</th>
                        {/* TODO: implement in head for sorting onClick={() => prop} */}
                        <th>Siste status</th>
                        <th> </th>
                    </tr>
                </thead>
                <tbody>
                    {messages
                        ? messages.map((m: Message) => {
                              debugger
                              const dataObject = new Date(m.lastUpdate)
                              const { style, Icon, color } = statusChecker(
                                  m.latestMessageStatus
                              )

                              return (
                                  <tr
                                      className={styles.tablerow}
                                      onClick={() =>
                                          onChangeActive(m.messageId)
                                      }
                                      key={m.id}
                                  >
                                      <td>
                                          {dirCheck
                                              ? m.senderIdentifier
                                              : m.receiverIdentifier}
                                      </td>
                                      <td>
                                          {new Intl.DateTimeFormat('en-GB', {
                                              timeZone: 'Europe/Oslo',
                                              hour12: false,
                                              formatMatcher: 'best fit',
                                              day: '2-digit',
                                              month: '2-digit',
                                              year: 'numeric',
                                              hour: 'numeric',
                                              minute: 'numeric',
                                          }).format(dataObject)}
                                      </td>
                                      <td>{m.latestMessageStatus}</td>
                                      <td className={styles[style]}>
                                          <IconContext.Provider
                                              value={{
                                                  color,
                                                  size: '5em',
                                                  className: 'react-icons',
                                              }}
                                          >
                                              <Icon />
                                          </IconContext.Provider>
                                      </td>
                                  </tr>
                              )
                          })
                        : null}
                </tbody>
            </table>
        </div>
    )
}

export default InOrOutbox
