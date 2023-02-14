import { useReducer } from 'react'
import { Link } from 'react-router-dom'
import { Input } from '../../components/ui/Input'
import { PrimaryButton } from '../../components/ui/PrimaryButton'
import { api_path } from '../../utils/api'
import './Login.css'

interface LoginForm {
  email: string,
  password: string,
}

export const Login = () => {
  const [state, dispatch] = useReducer((state: LoginForm, action: { [key: string]: string }) => ({
    ...state,
    ...action,
  }), {
    email: "",
    password: "",
  })

  const fetchLogin = async () => {
    const url = `${api_path}/api/account/doctor/login`
    const response = await fetch(url, {
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(state)
    })
    const data = await response.json()
    console.log(data);
  }

  return (
    <main className="main--login">
        <div className="login-container">
            <h1 style={{marginBlockEnd: 35}} className='main--login'>Logowanie</h1>
            <Input label='email' type='email' style={{marginBlockEnd: 15}} onChange={(v) => dispatch({ "email": v })} />
            <Input label='hasło' type='password' onChange={(v) => dispatch({ "password": v })}/>
            <Link to={"/password-forgot"} className="input--link" style={{marginBlockStart: 50, cursor: 'pointer'}}>Przypomnij hasło</Link>
            <PrimaryButton style={{height: 56, marginBlockStart: 15}}>Zaloguj się</PrimaryButton>
        </div>
    </main>
  )
}
