import React, {useContext, useState} from 'react';
import classes from "./GetFileBD.module.css";
import MyInput from "../input/MyInput";
import MyButton from "../button/MyButton";
import {useFetching} from "../../../hooks/useFetching";
import BackService from "../../../API/BackService";
import {AuthContext} from "../../../context";

const GetFileBd = () => {
    const {token} = useContext(AuthContext)
    const [fileUrl, setFileUrl] = useState("")

    const [getJsonURl, isLoadJsonURL, errorJsonURL] = useFetching(async () => {
        const response = await  BackService.getProductsJSON(token.token)
        setFileUrl(response.data)
    })
    const [getCsvURl, isLoadCsvURL, errorCsvURL] = useFetching(async () => {
        const response = await  BackService.getProductsCSV(token.token)
        setFileUrl(response.data)
    })

    function getJson(event) {
        event.preventDefault();
        getJsonURl()
    }
    function getCsv(event) {
        event.preventDefault();
        getCsvURl()
    }

    return (
        <div className={classes.GetFileBD}>
            <div className={classes.GetFileBD_InfoContainer}>
                <div className={classes.GetFileBD_InfoContainer_Wrapper}>
                    <div style={{width: "300px"}}>
                        <MyButton onClick={getJson}>
                            Получить Json
                        </MyButton>
                    </div>
                    <div style={{width: "300px"}}>
                        <MyButton onClick={getCsv}>
                            Получить Csv
                        </MyButton>
                    </div>
                    <div className={classes.GetFileBD_Title}>
                        <div className={classes.GetFileBD_Title_Text}>
                            Ссылка на репозиторий: {fileUrl}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default GetFileBd;