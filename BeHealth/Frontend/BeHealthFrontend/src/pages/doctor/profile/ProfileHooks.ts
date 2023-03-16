import { api_path } from "../../../utils/api";

export const useAddCertificate = (file: File, id: string) => {
    return (async () => {
        const formData = new FormData()
        formData.append("image", file)
        const response = await fetch(`${api_path}/api/doctors/${id}/certificates`,
        {
            method: 'POST',
            body: formData,
        });
        const body = await response.text();
        return `${api_path}/Images/${body}`
    })();
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