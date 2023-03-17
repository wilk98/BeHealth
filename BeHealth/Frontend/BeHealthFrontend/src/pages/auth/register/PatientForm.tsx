import { Input } from "../../../components/ui/Input"
import { FormFields } from "./Register"

export const PatientFields = ({ state, dispatch }:FormFields) => {
  return (
    <>
      <div className="split-row">
        <Input label='imię' type={'text'} value={state.firstName} onChange={(v) => dispatch({ firstName: v })} />
        <Input label='nazwisko' type={'text'} value={state.lastName} onChange={(v) => dispatch({ lastName: v })} />
      </div>
      <Input label='Numer telefonu' type={'tel'} value={state.phoneNumber} onChange={(v) => dispatch({ phoneNumber: v })} />
      <Input label='Email' type={'email'} value={state.email} onChange={(v) => dispatch({ email: v })} />
      <Input label='Miasto' type={'text'} value={state.city} onChange={(v) => dispatch({ city: v })} />
      <Input label='Ulica' type={'text'} value={state.street} onChange={(v) => dispatch({ street: v })} />
      <Input label='Kod pocztowy' type={'text'} value={state.postalCode} onChange={(v) => dispatch({ postalCode: v })} />
      <Input label='Pesel' type={'number'} value={state.pesel} onChange={(v) => dispatch({ pesel: v })} />
      <Input label='Hasło' type={'password'} value={state.passwordHash} onChange={(v) => dispatch({ passwordHash: v })} />
      <Input label='Podtwierdzenie hasła' type={'password'} value={state.confirmPassword} onChange={(v) => dispatch({ confirmPassword: v })} />
    </>
  )
}