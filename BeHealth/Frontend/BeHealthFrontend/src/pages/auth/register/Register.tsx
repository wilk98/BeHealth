import { Logo } from '../../../components/layout/Logo'
import doctorImage from '../../../assets/images/doctorRegistration.png'
import './Register.css'
import { PrimaryButton } from '../../../components/ui/PrimaryButton'
import { useReducer, useState } from 'react'
import { api_path } from '../../../utils/api'
import { DoctorFields } from './DoctorForm'
import { PatientFields } from './PatientForm'

export interface FormFields {
  state: User,
  dispatch: React.Dispatch<{ [key: string]: string; }>
}

interface User {
  firstName: string,
  lastName: string,
  phoneNumber: string,
  email: string,
  city: string,
  street: string,
  postalCode: string,
  specialist: string,
  pesel: string,
  passwordHash: string,
  confirmPassword: string
}

export const Register = () => {

  const createUser = async () => {
    const url = `${api_path}/api/account/${userType == 'Doctor' ? 'doctor' : 'patient'}/register`
    setLoading(true)
    const response = await fetch(url, {
      method: "POST",
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(state)
    })
    const data = await response.json()
    setLoading(false)
    if (data.status == 400) {
      for (const key in data.errors) {
        if (Object.prototype.hasOwnProperty.call(data.errors, key)) {
          const errors = data.errors[key];
          const errorsArray:Array<string> = []
          for (const error of errors) {
            errorsArray.push(error)
          }
          setErrors(errorsArray)
        }
      }
    }
    else {
      setErrors([])
    }
  };

  const [userType, setUserType] = useState<"Doctor" | "Patient">("Patient")
  const [loading, setLoading] = useState(false)
  const [errors, setErrors] = useState(Array<string>())
  const [state, dispatch] = useReducer((state: User, action: {[key: string]: string }) => (
    {
      ...state,
      ...action
    }
  ), {
    firstName: "",
    lastName: "",
    phoneNumber: "",
    email: "",
    city: "",
    street: "",
    postalCode: "",
    specialist: "",
    pesel: "",
    passwordHash: "",
    confirmPassword: ""
  })

  return (
    <main className='main--register'>
      <div className="split">
        <div className="doctor">
          <Logo fontSize={64} />
          <img src={doctorImage} alt="Smiling woman in doctor's wear" />
          <p style={{ fontSize: "1.1rem", marginBlockStart: 10, fontWeight: 600 }}>Zarezewuj swoją pierwszą wizytę już za 5 minut!</p>
        </div>
        <div className="registration-container">
          <h1>Rejestracja</h1>
          { errors.length != 0 && <h3 className='register--error'>{errors}</h3>}
          {userType == "Doctor" ? <DoctorFields dispatch={dispatch} state={state} /> : <PatientFields dispatch={dispatch} state={state} />}
          <fieldset>
            <div className="split">
              <div>
                <input type="radio" name="user-type" id="user-type-1" value="patient" checked={userType === "Patient"} onChange={() => setUserType("Patient")} />
                <label htmlFor="user-type-1">Jako pacjent</label>
              </div>
              <div>
                <input type="radio" name="user-type" id="user-type-2" value="doctor" checked={userType === "Doctor"} onChange={() => setUserType("Doctor")} />
                <label htmlFor="user-type-1">Jako lekarz</label>
              </div>
            </div>
          </fieldset>
          <PrimaryButton disabled={loading} style={{ width: 390, height: 53, marginBlockStart: 30 }} onClick={createUser}>Zarejestruj się</PrimaryButton>
        </div>
      </div>
    </main>
  )
}
