import './Input.css'

interface Input {
    label: string,
    type: React.HTMLInputTypeAttribute
    style?: React.CSSProperties
}

export const Input = ({ label, type, style }:Input) => {
    return (
        <div className="behealth--input-wrapper">
            <label htmlFor={`${label}--input`} className='behealth--label'>{label}</label>
            <input name={`${label}--input`} className='behealth--input' type={type} style={style} />
        </div>
    )
}
