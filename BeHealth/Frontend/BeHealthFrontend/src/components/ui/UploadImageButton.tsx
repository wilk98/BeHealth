import { useRef } from "react";
import { SecondaryButton } from "./SecondaryButton"

interface UploadImageButton {
    text: string,
    handleUpload: (file: File) => Promise<string>,
    onUpload: (url: string) => void,
}

export const UploadImageButton = ({ text, handleUpload, onUpload }: UploadImageButton) => {
    const hiddenFileInput: React.LegacyRef<HTMLInputElement> = useRef(null)
    const handleClick = () => {
        if (hiddenFileInput.current !== null)
            hiddenFileInput.current.click();
    }
    const handleChange: React.ChangeEventHandler<HTMLInputElement> = async (event) => {
        if (event.target.files === null)
            return
        const fileUploaded = event.target.files[0]
        const image = await handleUpload(fileUploaded)
        onUpload(image);
    }

    return (
        <>
            <SecondaryButton onClick={handleClick}>
                { text }
            </SecondaryButton>
            <input type={"file"}
                ref={hiddenFileInput}
                style={{ display: 'none' }}
                onChange={handleChange}
                accept="image/*" />
        </>
    )
}
