import { Certificate } from "./CertificatesSection"

export const useAddCertificate = (file: File) => {
    return new Promise<string>(resolve => resolve("https://slm-assets.secondlife.com/assets/21289908/view_large/Missing_Texture.jpg?1533890698"))
}

export const useFetchCertificates = () => {

    return new Promise<Array<string>>((resolve, reject) => {
        const certificates = [
                "https://img.freepik.com/free-vector/elegant-blue-gold-diploma-certificate-template_1017-17257.jpg?w=2000",
                "https://m.media-amazon.com/images/I/71bpEJf8IEL.jpg",
        ]
        resolve(certificates)
    })
}