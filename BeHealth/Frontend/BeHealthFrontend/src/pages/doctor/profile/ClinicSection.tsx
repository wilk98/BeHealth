import { useState } from "react";
import { IoMdSettings } from "react-icons/io";
import { Modal } from "../../../components/ui/Modal";
import { SecondaryButton } from "../../../components/ui/SecondaryButton"
import { AddClinic } from "./AddClinic";
import { useFetchClinics } from "./ProfileHooks";

export interface Clinic {
    id: number,
    name: string,
    address: string,
}

export const Clinic = ({ name, address }: Clinic) => {
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

export const ClinicsSection = () => {
    const [showModal, setShowModal] = useState(true);
    const [clinics, setClinics] = useState<Clinic[]>([]);

    const handleClose = () => setShowModal(false);
    const handleOpen = () => setShowModal(true);
    const addClinic = (name: string, address: string) => { setClinics(prevClinics => {
        return [...prevClinics, { name: name, address: address, id: prevClinics.length + 1 }]
    }) };

    useFetchClinics(setClinics);

    const Clinics = clinics?.map(clinic => <Clinic key={clinic.id} name={clinic.name} address={clinic.address} id={clinic.id} />);
    return (
        <section className="clinics">
            <div className="row">
                <p className="section-title">Przychodnie</p>
                <SecondaryButton onClick={handleOpen}>
                    Dodaj
                </SecondaryButton>
            </div>
            <div className="clinics-row">
                {Clinics}
            </div>
            <Modal title="Dodaj przychodnie" content={<AddClinic closeModal={handleClose} addClinic={addClinic} />} show={showModal} close={handleClose} />
        </section>
    )
}
