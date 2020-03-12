import React from 'react'
import Message from '../../../types/Message'
import { statusChecker, parseDate } from '../../../utils/utils'
import styles from './styles.module.css'
import classnames from 'classnames'
import SearchSenderReceiver from '../../containers/SearchSenderReceiver'

type InOrOutboxProps = {
    direction: 'IN' | 'OUT'
    messages: Message[]
    onChangeActive: (messageId: string) => void
    // onDateSort: () => void
    //TODO: Fortesett trykk på header for å sortere ting i listen
} & FilterBoxProps

type FilterBoxProps = {
    onSearchSenderId: (id: string) => void
    onSearchReceiverId: (id: string) => void
    onClearIncomingMessages: () => void
    onClearOutgoingMessages: () => void
}

const InOrOutbox: React.FC<InOrOutboxProps> = props => {
    const dirCheck = props.direction === 'IN'

    return (
        <div className={styles.table}>
            <div className={styles.titleContainer}>
                <h2 className={styles.title}>
                    {dirCheck ? 'Innkommende' : 'Utgående'}
                </h2>
                <div className={styles.tableSearchField}>
                    {dirCheck ? (
                        <SearchSenderReceiver
                            placeholder={'Filtrer på avsender'}
                            onSearch={id => props.onSearchSenderId(id)}
                            onClear={props.onClearIncomingMessages}
                        />
                    ) : (
                        <SearchSenderReceiver
                            placeholder={'Filtrer på mottaker'}
                            onSearch={id => props.onSearchReceiverId(id)}
                            onClear={props.onClearOutgoingMessages}
                        />
                    )}
                </div>
            </div>
            <table>
                <thead>
                    <tr className={styles.tableHeader}>
                        <th>ID</th>
                        <th>{dirCheck ? 'Avsender' : 'Mottaker'}</th>
                        <th>Tid opprettet</th>
                        <th>Sist oppdatert</th>
                        <th>Type</th>
                        <th>Siste status</th>
                    </tr>
                </thead>

                <tbody>
                    {props.messages
                        ? props.messages.map((m: Message) => {
                              const firstDateObject = new Date(m.created)
                              const lastDateObject = new Date(m.lastUpdate)
                              const { style } = statusChecker(
                                  m.latestMessageStatus
                              )
                              const styling = classnames(
                                  styles[style],
                                  styles.bold
                              )
                              return (
                                  <tr
                                      className={styles.tablerow}
                                      onClick={() =>
                                          props.onChangeActive(m.messageId)
                                      }
                                      key={m.id}
                                  >
                                      <td>{m.conversationId.slice(0, 9)}</td>
                                      <td>
                                          {dirCheck
                                              ? m.senderIdentifier
                                              : m.receiverIdentifier}
                                      </td>
                                      <td>{parseDate(firstDateObject)}</td>
                                      <td>{parseDate(lastDateObject)}</td>
                                      <td>{m.serviceIdentifier}</td>
                                      <td className={styling}>
                                          {m.latestMessageStatus}
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
