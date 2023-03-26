import { useReducer } from "react";
import { Input } from "../../../components/ui/Input"
import { PrimaryButton } from "../../../components/ui/PrimaryButton"
import { useAddClinic } from "./ProfileHooks";

interface AddClinicProps {
    closeModal: () => void;
    addClinic: (name: string, address: string) => void;
}

interface Clinic {
    name: string;
    address: string;
}

interface Action {
    type: 'name' | 'address';
    payload: string;
}

export const AddClinic = ({ closeModal, addClinic }: AddClinicProps) => {
    const [clinic, dispatch] = useReducer((state: Clinic, action: Action) => {
        switch (action.type) {
            case "name":
                return { ...state, name: action.payload };
            case "address":
                return { ...state, address: action.payload };
            default:
                return state;
        }
    }, { name: "", address: "" });

    const handleAddClinic = () => {
        useAddClinic(clinic.name, clinic.address);
        addClinic(clinic.name, clinic.address);
        closeModal();
    }

    return (
        <div>
            <Input label="Nazwa" type={"text"} style={{ minWidth: 300 }} onChange={(value) => dispatch({ type: 'name', payload: value})} />
            <Input label="Adres" type={"text"} style={{ minWidth: 300 }} onChange={(value) => dispatch({ type: 'address', payload: value})}/>
            <PrimaryButton style={{ marginBlockStart: "1rem" }} onClick={handleAddClinic}>Dodaj</PrimaryButton>
        </div>
    )
}