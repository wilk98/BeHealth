import './HamburgerButton.css'

export const HamburgerButton = ({ isOpen, onClick }: { isOpen: boolean, onClick: () => void }) => {
  return (
    <label className='hamburger' htmlFor="check">
      <input type="checkbox" id="check" checked={isOpen} onChange={onClick} /> 
      <span></span>
      <span></span>
      <span></span>
    </label>
  )
}
