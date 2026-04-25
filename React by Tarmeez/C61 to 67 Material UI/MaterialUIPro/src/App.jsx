import './App.css'
import MaterialButton from "./MaterialButton"
import { createTheme , ThemeProvider } from '@mui/material/styles'
import { orange  , green, blue} from '@mui/material/colors';
import GridTest from './GridTest';
import StackTest from './StackTest';
import Test from './Test';

const theme = createTheme({
  status: {
    danger: orange[500],
  },
  palette: {
    primary: {
      main: blue[500],
    },
    secondary: {
      main: green[500],
    },
  },
});
 

function App() {

  //ThemeProvider context to share theme variable to all app

  return (
      <ThemeProvider theme={theme}> 

        <>
       
        <Test/>
        </>
      </ThemeProvider>

  )
}

export default App



/* <div style={{ margin: "200px" }} >
          <MaterialButton/>
        </div>

          <GridTest/>
                    <StackTest/>*/ 