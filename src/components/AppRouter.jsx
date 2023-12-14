import React, {useContext} from 'react';
import {Navigate, Route, Routes} from "react-router-dom";
import {privateRoutes, publicRoutes} from "../router";
import {AuthContext} from "../context";
import Loader from "./UI/Loader/Loader";
import Main from "../pages/Main";

const AppRouter = () => {
    const {isAuth, isLoading} = useContext(AuthContext);
    console.log(isAuth)

    if (isLoading) {
        return <Loader/>
    }
    //<Navigate to='/posts'/>
    return (
        isAuth
            ?
            <Routes>
                <Route path="/">
                    <Route index element={<Main/>} />
                </Route>
            </Routes>
            :
            <Routes>
                <Route path="/">
                    <Route index element={<Main/>} />
                </Route>
            </Routes>
    );
    // <Navigate to='/login'/>
};

export default AppRouter;
