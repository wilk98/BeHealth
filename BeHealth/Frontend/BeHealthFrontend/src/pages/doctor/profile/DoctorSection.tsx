import { ReactNode } from "react"
import { BsFillTelephoneFill } from "react-icons/bs"
import { FaUserNurse } from "react-icons/fa"
import { HiOutlineMail } from "react-icons/hi"

interface Badge {
    text: string,
    icon: ReactNode,
}

const Badge = ({ text, icon }: Badge) => {
    return (
        <div className="badge" >
            {icon}
            <p className="badge--text">{text}</p>
        </div >
    )
}

export const DoctorSection = () => {
    // TODO Use data from user in context
    return (
        <section className="user">
            <div className="row">
                <img src="https://www.gravatar.com/avatar/HASH" className="profile--img" />
                <div className="user">
                    <p className="username">Maryna Wanessa</p>
                    <p className="information">Dołączono Wrz 2021 · Kraków, Polska</p>
                </div>
            </div>
            <div className="badge-row">
                <Badge text="maryna.waness@gmail.com" icon={<HiOutlineMail />} />
                <Badge text="+48 777-777-777" icon={<BsFillTelephoneFill className="filled" />} />
                <Badge text="Terapeuta" icon={<FaUserNurse className="filled" />} />
            </div>
        </section>
    )
}
