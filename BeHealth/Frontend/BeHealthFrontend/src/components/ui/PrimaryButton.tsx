import './PrimaryButton.css'

interface PrimaryButton {
  children: React.ReactNode;
  style: React.CSSProperties;
  disabled?: boolean;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

export const PrimaryButton = ({ children, style, onClick, disabled = false }: PrimaryButton ) => {
  style = {
    ...style,
    cursor: 'pointer'
  }
  return (
    <button className={disabled ? 'disabled' : ''} style={style} onClick={(event) => (onClick && !disabled) && onClick(event)}>{children}</button>
  )
}