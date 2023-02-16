import { useReducer, useState, useContext } from 'react'
import { Link } from 'react-router-dom'
import { Input } from '../../components/ui/Input'
import { PrimaryButton } from '../../components/ui/PrimaryButton'
import { BeHealthContext } from '../../Context'
import { api_path } from '../../utils/api'
import { getParsedJwt, Token, User } from '../../utils/auth'
import './Login.css'

interface LoginForm {
  email: string,
  password: string,
}

export const Login = () => {
  const [error, setError] = useState("")
  const [state, dispatch] = useReducer((state: LoginForm, action: { [key: string]: string }) => ({
    ...state,
    ...action,
  }), {
    email: "",
    password: "",
  })
  const { setUser, setToken } = useContext(BeHealthContext)

  const fetchLogin = async () => {
    const url = `${api_path}/api/account/doctor/login`
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(state)
    })
    if (response.status != 200)
    {
      setError('Nieprawidłowa nazwa użytkownika lub hasło!')
      return;
    }
    else if (!response.headers.get('Content-Type')?.includes('text/plain;'))
    {
      console.error(`Api should return token as a plain text got: "${response.headers.get('Content-Type')}"`);
      return;
    }
    setError('')

    const token = await response.text();
    const parsedToken = getParsedJwt<Token>(token);

    setToken(token)

    if (parsedToken === undefined)
      return;

    const user: User = {
      id: parsedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
      name: parsedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
      role: parsedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
    }
    setUser(user)
  }

  return (
    <main className="main--login">
        <div className="login-container">
            <h1 style={{marginBlockEnd: 35}} className='main--login'>Logowanie</h1>
            <h3 className="login--error">{error}</h3>
            <Input label='email' type='email' style={{marginBlockEnd: 15}} onChange={(v) => dispatch({ "email": v })} />
            <Input label='hasło' type='password' onChange={(v) => dispatch({ "password": v })}/>
            <Link to={"/password-forgot"} className="input--link" style={{marginBlockStart: 50, cursor: 'pointer'}}>Przypomnij hasło</Link>
            <PrimaryButton style={{height: 56, marginBlockStart: 15}} onClick={fetchLogin}>Zaloguj się</PrimaryButton>
        </div>
    </main>
  )
}
