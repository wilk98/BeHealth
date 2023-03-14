import { useEffect, useState } from "react";
import { UploadImageButton } from "../../../components/ui/UploadImageButton"
import { useAddCertificate, useFetchCertificates } from "./ProfileHooks";

export interface Certificate {
    url: string
}

const Certificate = ({ url }: Certificate) => {
    return (
        <img src={url} alt="" className="certificate" />
    )
}

export const CertificatesSection = () => {
    const [certificates, setCertificates] = useState<Array<Certificate>>([])
    const addCertificate = (url: string) => setCertificates(prev => [...prev, { url: url }])
    const certificateElements = certificates?.map(certificate => <Certificate key={certificate.url} url={certificate.url} />)

    useEffect(() => {
      (async () => {
        const urls = await useFetchCertificates()
        const certificates = urls.map(url => ({ url: url }))
        setCertificates(certificates)
      })()
    }, [])

    return (
        <section className="certificates">
            <div className="row">
                <p className="section-title">Wykształcenie</p>
                <UploadImageButton text="Dodaj" handleUpload={useAddCertificate} onUpload={addCertificate} />
            </div>
            <div className="certificates-row">
                {certificateElements}
            </div>
        </section>
    )
}
