import { useRef, useEffect } from 'react'

export default <T extends unknown>(messages: T) => {
    const ref = useRef<T>()

    useEffect(() => {
        ref.current = messages
    }, [messages])
    return ref.current
}
