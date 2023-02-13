import { Logo } from '../../components/layout/Logo'
import doctorImage from '../../assets/images/doctorRegistration.png'
import './Register.css'
import { Input } from '../../components/ui/Input'
import { PrimaryButton } from '../../components/ui/PrimaryButton'
import { useState } from 'react'

const PatientFields = () => {
  return (
    <>
      <div className="split-row">
        <Input label='imię' type={'text'} />
        <Input label='nazwisko' type={'text'} />
      </div>
      <Input label='Numer telefonu' type={'tel'} />
      <Input label='Email' type={'email'} />
      <Input label='Miasto' type={'text'} />
      <Input label='Ulica' type={'text'} />
      <Input label='Kod pocztowy' type={'text'} />
      <Input label='Pesel' type={'number'} />
      <Input label='Hasło' type={'password'} />
      <Input label='Podtwierdzenie hasła' type={'password'} />
    </>
  )
}

const DoctorFields = () => {
  return (
    <>
      <div className="split-row">
        <Input label='imię' type={'text'} />
        <Input label='nazwisko' type={'text'} />
      </div>
      <Input label='Numer telefonu' type={'tel'} />
      <Input label='Email' type={'email'} />
      <Input label='Miasto' type={'text'} />
      <Input label='Ulica' type={'text'} />
      <Input label='Kod pocztowy' type={'text'} />
      <Input label='Specjalizacja' type={'text'} />
      <Input label='Hasło' type={'password'} />
      <Input label='Podtwierdzenie hasła' type={'password'} />
    </>
  )
}

export const Register = () => {

  const [userType, setUserType] = useState<"Doctor" | "Patient">("Patient")

  return (
    <main className='main--register'>
      <div className="split">
        <div className="doctor">
          <Logo fontSize={64} />
          <img src={doctorImage} alt="Smiling woman in doctor's wear" />
          <p style={{fontSize: "1.1rem", marginBlockStart: 10, fontWeight: 600}}>Zarezewuj swoją pierwszą wizytę już za 5 minut!</p>
        </div>
        <div className="registration-container">
          <h1>Rejestracja</h1>
          {userType == "Doctor" ? <DoctorFields /> : <PatientFields /> }
          <fieldset>
            <div className="split">
              <div>
                <input type="radio" name="user-type" id="user-type-1" value="patient" onChange={() => setUserType("Patient")}/>
                <label htmlFor="user-type-1">Jako pacjent</label>
              </div>
              <div>
                <input type="radio" name="user-type" id="user-type-2" value="doctor" onChange={() => setUserType("Doctor")} />
                <label htmlFor="user-type-1">Jako lekarz</label>
              </div>
            </div>
          </fieldset>
          <PrimaryButton style={{ width: 390, height: 53, marginBlockStart: 30 }}>Zarejestruj się</PrimaryButton>
        </div>
      </div>
    </main>
  )
}
