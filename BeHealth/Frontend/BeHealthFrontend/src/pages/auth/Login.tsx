import { Link } from 'react-router-dom'
import { Input } from '../../components/ui/Input'
import { PrimaryButton } from '../../components/ui/PrimaryButton'
import './Login.css'

export const Login = () => {
  return (
    <main className="main--login">
        <div className="login-container">
            <h1 style={{marginBlockEnd: 35}} className='main--login'>Logowanie</h1>
            <Input label='email' type='email' style={{marginBlockEnd: 15}} />
            <Input label='hasło' type='password' />
            <Link to={"/password-forgot"} className="input--link" style={{marginBlockStart: 50, cursor: 'pointer'}}>Przypomnij hasło</Link>
            <PrimaryButton style={{height: 56, marginBlockStart: 15}}>Zaloguj się</PrimaryButton>
        </div>
    </main>
  )
}
