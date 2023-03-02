import './Sidebar.css'
import {  FaRegCalendar, FaRegClipboard, FaRegUser, IoSettingsSharp, FiMessageSquare, GiHealthNormal, BsCardList, TbNotes } from 'react-icons/all'
import { useContext, useState } from 'react'
import { Logo } from './Logo';
import { HamburgerButton } from '../ui/HamburgerButton';
import { Link, LinkProps } from 'react-router-dom';
import { BeHealthContext } from '../../Context';

interface Sidebar {
  isOpen: boolean;
  toggle: () => void;
}

export const Sidebar = ({ isOpen, toggle }: Sidebar) => {
  const [selected, setSelected] = useState(0)
  const { user } = useContext(BeHealthContext)
  const show = user !== undefined

  interface Link {
    name: string,
    link: string,
    icon: JSX.Element,
  }

  const patientLinks: Array<Link> = [
    {
      name: "Kalendarz",
      link: "/calendar",
      icon: <FaRegCalendar />,
    },
    {
      name: "Profil",
      link: "/",
      icon: <FaRegUser />
    },
    {
      name: "Wiadomości",
      link: "/",
      icon: <FiMessageSquare />,
    },
    {
      name: "Recepty",
      link: "/",
      icon: <BsCardList />,
    },
    {
      name: "Skierowania",
      link: "/referrals",
      icon: <TbNotes />,
    },
    {
      name: "Wizyty",
      link: "/",
      icon: <FaRegClipboard />,
    },
  ]

  const doctorLinks: Array<Link> = [
    {
      name: "Kalendarz",
      link: "/calendar",
      icon: <FaRegCalendar />,
    },
    {
      name: "Nadchodzące wizyty",
      link: "/visits",
      icon: <FaRegClipboard />,
    },
    {
      name: "Profil",
      link: "/",
      icon: <FaRegUser />,
    },
    {
      name: "Wiadomości",
      link: "/",
      icon: <FiMessageSquare />,
    },
    {
      name: "Pacjenci",
      link: "/",
      icon: <GiHealthNormal />,
    },
    {
      name: "Ustawienia",
      link: "/",
      icon: <IoSettingsSharp />,
    },
  ]

  const LinksList = () => {

    const { user } = useContext(BeHealthContext)
    const links = user?.role === 'Doctor' ? doctorLinks : patientLinks

    return (
      <>
        {
        links.map((link, i) => (
            <li key={link.name} onClick={() => setSelected(i)}  className={selected === i ? 'selected ' : ''}>
              <Link to={link.link}>{link.icon} {link.name}</Link>
            </li>
          ))
        }
      </>
    )
  }

  return (
    <aside className={!isOpen ? 'hidden' : ''} style={{
      transform: !show ? 'translateX(-370px) translateY(-135px)' : ''
    }}>
      <div className='controls'>
        <Logo />
        <HamburgerButton isOpen={isOpen} onClick={toggle} />
      </div>
      <ul>
        <LinksList />
      </ul>
    </aside>
  )
}
