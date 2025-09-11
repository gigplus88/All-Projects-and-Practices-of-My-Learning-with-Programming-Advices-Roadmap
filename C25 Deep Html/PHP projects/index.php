<!DOCTYPE html>
<?php  $Name = "Salim"?> 

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PHP Page | <?php echo $Name ?> 
    </title>
</head>
<body>
    
    <div> Welcome <?php echo $Name ?> </div>
    <div> Your Score is 1000 points</div>

    <div> 
    <?php include("Score.php") ?>
    </div>


   

</body>
</html>