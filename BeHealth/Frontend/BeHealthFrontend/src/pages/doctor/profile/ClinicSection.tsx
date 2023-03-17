import { IoMdSettings } from "react-icons/io";
import { SecondaryButton } from "../../../components/ui/SecondaryButton"
import { ClinicsList } from "./MockClinics"

export interface Clinic {
    id: number,
    name: string,
    address: string,
}

const Clinic = ({ name, address }: Clinic) => {
    return (
        <div className="clinic">
            <p className="clinic--title">
                {name}
            </p>
            <p className="clinic--address">
                {address}
            </p>
            <IoMdSettings className="clinic--settings" />
        </div>
    )
}

// TODO Create custom hook for fetching real clinics
const Clinics = ClinicsList.map((clinic) => <Clinic key={clinic.id} name={clinic.name} address={clinic.address} id={clinic.id} />);

export const ClinicsSection = () => {
    return (
        <section className="clinics">
            <div className="row">
                <p className="section-title">Przychodnie</p>
                {/* TODO Add callback that shows modal with work hour setting */}
                <SecondaryButton>
                    Dodaj
                </SecondaryButton>
            </div>
            <div className="clinics-row">
                {Clinics}
            </div>
        </section>
    )
}
