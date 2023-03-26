import { useState, useContext } from "react";
import { UploadImageButton } from "../../../components/ui/UploadImageButton"
import { BeHealthContext } from "../../../Context";
import { useAuth } from "../../auth/hooks/useAuth";
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

    const user = useAuth("/profile");
    const id = user?.id;

    if (id === undefined) {
        return (
            <section className="certificates"></section>
        )
    }


    useFetchCertificates(id, setCertificates)

    return (
        <section className="certificates">
            <div className="row">
                <p className="section-title">Wykształcenie</p>
                <UploadImageButton text="Dodaj" handleUpload={(file) => useAddCertificate(file, id)} onUpload={addCertificate} />
            </div>
            <div className="certificates-row">
                {certificateElements}
            </div>
        </section>
    )
}

