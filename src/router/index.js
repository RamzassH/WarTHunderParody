import Main from "../pages/Main";


export const privateRoutes = [
    {path: '/main', element: <Main/>, exact: true},

]

export const publicRoutes = [
    {path: '/main_non_avt', element: <Main/>, exact: true},
]
