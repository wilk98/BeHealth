import { redirect, useNavigate } from 'react-router-dom'
import { useState, useContext, useRef } from 'react'
import { Link } from 'react-router-dom'
import { Input } from '../../components/ui/Input'
import { PrimaryButton } from '../../components/ui/PrimaryButton'
import { BeHealthContext } from '../../Context'
import { useLogin } from './hooks/useLogin'
import './Login.css'

export interface loginForm {
  email: string,
  password: string,
}

export const Login = () => {
  const [error, setError] = useState("")
  const navigate = useNavigate()

  let loginRef = useRef('')
  let password = useRef('')
  let isDoctor = useRef(false)

  const { setUser, setToken, urlRedirect } = useContext(BeHealthContext)
  const { error:loginError, token, user, login } = useLogin()

  if (error !== loginError) {
    setError(loginError)
  }

  if (error === '' && user !== undefined) {
    setToken(token)
    setUser(user)
    navigate(urlRedirect || "/")
  }

  return (
    <main className="main--login">
        <div className="login-container">
            <h1 style={{marginBlockEnd: 35}} className='main--login'>Logowanie</h1>
            <h3 className="login--error">{error}</h3>
            <Input label='email' type='email' style={{marginBlockEnd: 15}} onChange={(value) => loginRef.current = value} />
            <Input label='hasło' type='password' onChange={(value) => password.current = value} />
            <div>
                <input type="radio" name="user-type" id="user-type-1" value="patient" onChange={() => isDoctor.current = false} />
                <label htmlFor="user-type-1">Jako pacjent</label>
            </div>
            <div>
                <input type="radio" name="user-type" id="user-type-2" value="doctor" onChange={() => isDoctor.current = true} />
                <label htmlFor="user-type-2">Jako lekarz</label>
            </div>
            <Link to={"/password-forgot"} className="input--link" style={{marginBlockStart: 50, cursor: 'pointer'}}>Przypomnij hasło</Link>
            <PrimaryButton style={{height: 56, marginBlockStart: 15}} onClick={() => {
            login({ email: loginRef.current, password: password.current }, isDoctor.current);
            }}>Zaloguj się</PrimaryButton>
        </div>
    </main>
  )
}
