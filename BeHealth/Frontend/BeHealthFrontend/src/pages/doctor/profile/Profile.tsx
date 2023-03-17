import './Profile.css'
import { ClinicsSection } from "./ClinicSection"
import { DoctorSection } from './DoctorSection'
import { CertificatesSection } from './CertificatesSection'

export const Profile = () => {
    return (
        <main className="main--profile">
            <DoctorSection />
            <hr />
            <ClinicsSection />
            <hr />
            <CertificatesSection />
        </main>
    )
}
