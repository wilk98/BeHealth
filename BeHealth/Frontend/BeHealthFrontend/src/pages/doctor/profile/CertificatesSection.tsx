import { useEffect, useState, useContext } from "react";
import { UploadImageButton } from "../../../components/ui/UploadImageButton"
import { BeHealthContext } from "../../../Context";
import { useAddCertificate, useFetchCertificates } from "./ProfileHooks";
import { useNavigate } from 'react-router-dom';

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

    const { user, setUrlRedirect } = useContext(BeHealthContext)
    const id = user?.id;
    const navigate = useNavigate()

    useEffect(() => {
        if (user === undefined) {
            setUrlRedirect("/profile")
            navigate("/login")
        }
    }, [])

    if (id === undefined) {
        return (
            <section className="certificates"></section>
        )
    }


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
                <UploadImageButton text="Dodaj" handleUpload={(file) => useAddCertificate(file, id)} onUpload={addCertificate} />
            </div>
            <div className="certificates-row">
                {certificateElements}
            </div>
        </section>
    )
}

