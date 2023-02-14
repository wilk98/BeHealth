import './Input.css'

interface Input {
    label: string,
    type: React.HTMLInputTypeAttribute,
    style?: React.CSSProperties,
    value?: string,
    onChange?: (value: string) => void,
}

export const Input = ({ label, type, style, onChange, value }:Input) => {
    return (
        <div className="behealth--input-wrapper">
            <label htmlFor={`${label}--input`} className='behealth--label'>{label}</label>
            <input name={`${label}--input`} value={value} className='behealth--input' type={type} style={style} onChange={e => onChange && onChange(e.target.value) } />
        </div>
    )
}
