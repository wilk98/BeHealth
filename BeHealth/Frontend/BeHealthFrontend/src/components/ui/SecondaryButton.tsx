import './SecondaryButton.css'

interface SecondaryButton {
  children: React.ReactNode;
  style?: React.CSSProperties;
  disabled?: boolean;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

export const SecondaryButton = ({ children, style, onClick, disabled = false }: SecondaryButton ) => {
  style = {
    ...style,
    cursor: 'pointer'
  }
  return (
    <button className={disabled ? 'disabled secondary' : 'secondary'} style={style} onClick={(event) => (onClick && !disabled) && onClick(event)}>{children}</button>
  )
}
