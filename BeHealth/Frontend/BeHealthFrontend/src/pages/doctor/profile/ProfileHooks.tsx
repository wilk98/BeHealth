import { useEffect } from "react";
import { api_path } from "../../../utils/api";
import { Certificate } from "./CertificatesSection";
import { Clinic } from "./ClinicSection";
import { clinics } from "./MockClinics";

export const useAddCertificate = (file: File, id: string) => {
    return (async () => {
        const formData = new FormData()
        formData.append("image", file)
        const response = await fetch(`${api_path}/api/doctors/${id}/certificates`,
            {
                method: 'POST',
                body: formData,
            });
        const body = await response.text();
        return `${api_path}/Images/${body}`
    })();
}

export const useFetchCertificates = (id: string, setCertificates: (certificates: Certificate[]) => void) => {
    useEffect(() => {
        (async () => {
            const response = await fetch(`${api_path}/api/doctors/${id}/certificates`);
            let json: Array<string> = await response.json();
            json = json.map(url => `${api_path}/Images/${url}`)
            const certificates = json.map(url => ({ url: url }))
            setCertificates(certificates);
        })();
    }, [])
}

export const useFetchClinics = (setClinics: (clinics: Clinic[]) => void) => {
    useEffect(() => {
        (async () => {
            // const response = await fetch("MockClinics.json");
            // const json:Clinic[] = await response.json();
            const json = clinics;

            setClinics(json);
        })();
    }, [])
}

export const useAddClinic = (name: string, address: string) => {
    return (async () => {
        try {
            const response = await fetch(`${api_path}/api/doctors/clinics`,
                {
                    method: 'POST',
                    body: JSON.stringify({ name: name, address: address }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
            const body = await response.json();
            return body;
        } catch (error) {
            console.log(error);
        }
    })();
}