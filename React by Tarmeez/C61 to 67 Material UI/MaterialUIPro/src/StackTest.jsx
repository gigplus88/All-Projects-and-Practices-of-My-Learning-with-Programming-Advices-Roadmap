import Box from "@mui/material/Box";
import Paper from "@mui/material/Paper";
import Stack from "@mui/material/Stack";
import { styled } from "@mui/material/styles";
import Divider from "@mui/material/Divider";
import Container from "@mui/material/Container";
import SvgIcon from '@mui/material/SvgIcon';
import AddIcon from '@mui/icons-material/Add';

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: (theme.vars ?? theme).palette.text.secondary,
  ...theme.applyStyles("dark", {
    backgroundColor: "#1A2027",
  }),
}));
function HomeIcon(props) {
  return (
    <SvgIcon {...props}>
      <path d="M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z" />
    </SvgIcon>
  );
}
export default function StackTest() {
  return (
    <Container maxWidth="lg" >
        <Stack
            spacing={10}
            direction="row"
            divider={<Divider orientation="vertical" flexItem />}
            
        >
            <Item>Item 1</Item>
            <Item>Item 2</Item>
            <Item>Item 3</Item>
         </Stack>
          <HomeIcon   color = "primary" />
          <AddIcon style = {{ color: "secondary" , fontSize:"60px" }} />
     <h2>item</h2>
     <h2>item2</h2>
    </Container>
  );
}
