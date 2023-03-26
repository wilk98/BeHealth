import './Modal.css'
import { ImCross } from "react-icons/im";

interface ModalProps {
    title: string;
    content: React.ReactNode;
    show: boolean;
    close: () => void;
}

export const Modal = ({ title, content, show, close }: ModalProps) => {
    const modalClass = show ? "modal" : "modal modal-hidden";

    return (
        <div className={modalClass}>
            <div className="modal-title">
                <h1>{title}</h1>
                <ImCross onClick={close} className="modal-title--close" />
            </div>
            <hr />
            <div className="modal-content">
                {content}
            </div>
        </div>
    )
}