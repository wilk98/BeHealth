import { SecondaryButton } from "../../../components/ui/SecondaryButton"
import { CertificatesList } from "./MockCertificates"

export interface Certificate {
    url: string
}

const Certificate = ({ url }: Certificate) => {
    return (
        <img src={url} alt="" className="certificate" />
    )
}

// TODO Create custom hook for fetching real certificates
const Certificates = CertificatesList.map(certificate => <Certificate key={certificate.url} url={certificate.url} />)

export const CertificatesSection = () => {
    return (
        <section className="certificates">
            <div className="row">
                <p className="section-title">Wykształcenie</p>
                {/* TODO Add callback that adds new certificate */}
                <SecondaryButton>
                    Dodaj
                </SecondaryButton>
            </div>
            <div className="certificates-row">
                {Certificates}
            </div>
        </section>
    )
}
