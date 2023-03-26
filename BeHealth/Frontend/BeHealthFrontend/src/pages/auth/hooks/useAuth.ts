import { useContext, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { BeHealthContext } from '../../../Context'
import { User } from '../../../utils/auth'

export const useAuth = (urlRedirect: string): User | undefined => {
    const { user, setUrlRedirect } = useContext(BeHealthContext)

    if (user === undefined) {
        const navigate = useNavigate()
        useEffect(() => {
            setUrlRedirect(urlRedirect)
            navigate("/login")
        }, [])
    }

    return user
}